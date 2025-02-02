import {
  Component,
  OnInit,
  inject
} from '@angular/core';
import { TableViewModel } from '../../shared/table/Models/TableViewModel';
import { CustomersService } from '../../services/customers.service';
import { MatDialog } from '@angular/material/dialog';
import { OrdersViewComponent } from '../../components/orders-view/orders-view.component';
import { NewOrderComponent } from '../../components/new-order/new-order.component';
import { SalesOrders } from '../../interfaces/SalesOrders';
import { FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {
  showTable: boolean = false;
  sales!: SalesOrders[];
  table!: TableViewModel;
  searchCompany = new FormControl('');

  private readonly customersService = inject(CustomersService);
  private readonly dialog = inject(MatDialog);

  ngOnInit(): void {
    this.changesFilter();
    this.getOrdersPrediction();
  }

  /**
   * Abre modal para adicionar una nueva orden
   * 
   * @param customer DTO del cliente
   */
  addNewOrder(customer: any) {
    const dialogRef = this.dialog.open(NewOrderComponent, {
      data: customer,
      width: '40%',
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.getOrdersPrediction();
        this.showTable = false;
      }
    });
  }

  /**
   * Abre modal de las ordenes del cliente
   * 
   * @param customer DTO del cliente
   */
  viewOrders(customer: any) {
    this.dialog.open(OrdersViewComponent, {
      data: customer,
      width: '90%',
    });
  }

  /**
   * Metodo para obtener el listado de clientes con fechas previstas de entrega
   * 
   * @param searchCompany 
   */
  private getOrdersPrediction(searchCompany?: string): void {
    this.customersService.getPredictionSales(searchCompany).subscribe({
      next: (response) => {
        if (response.result) {
          this.showInfoTable(response.data);
        }
      },
    });
  }

  /**
   * Metodo que detecta cambios en el filtro y
   * ejecuta las petciones al backend
   */
  changesFilter(): void {
    this.searchCompany.valueChanges
      .pipe(
        debounceTime(500),
        distinctUntilChanged(),
        switchMap((customer) =>
          this.customersService.getPredictionSales(customer ?? '')
        )
      )
      .subscribe((response) => {
        if (response.result) {
          this.showInfoTable(response.data);
        }
      });
  }

  /**
   * Carga la información para la tabla
   * @param reponseService 
   */
  showInfoTable(reponseService: SalesOrders[]) {
    this.sales = reponseService;
    this.table = {
      columns: [
        { key: 'companyName', value: 'Customer Name', type: 'text' },
        { key: 'lastOrderDate', value: 'Last Order Date', type: 'date' },
        {
          key: 'nextPredicterOrder',
          value: 'Next Predicted Order',
          type: 'date',
        },
      ],
      data: this.sales,
      showActions: true,
    };
    this.showTable = true;
  }
}
