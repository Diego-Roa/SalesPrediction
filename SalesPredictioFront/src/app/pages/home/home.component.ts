import { Component, OnInit, inject } from '@angular/core';
import { TableViewModel } from '../../shared/table/Models/TableViewModel';
import { CustomersService } from '../../services/customers.service';
import { MatDialog } from '@angular/material/dialog';
import { OrdersViewComponent } from '../../components/orders-view/orders-view.component';
import { NewOrderComponent } from '../../components/new-order/new-order.component';
import { SalesOrders } from '../../interfaces/SalesOrders';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

  showTable: boolean = false;
  sales!: SalesOrders[];
  table!: TableViewModel;

  private readonly customersService = inject(CustomersService);
  private readonly dialog = inject(MatDialog);

  ngOnInit(): void {
    this.getOrdersPrediction();
  }

  addNewOrder(customer: any){
    const dialogRef = this.dialog.open( NewOrderComponent, {
      data: customer,
      width:'40%'
    });
    dialogRef.afterClosed().subscribe(result =>{
      if (result) {
        this.getOrdersPrediction();
        this.showTable = false;
      }
    })
  }

  viewOrders(customer: any){
    this.dialog.open(OrdersViewComponent,{
      data : customer
    })
  }

  /**
   * Metodo para obtener el listado de clientes con fechas previstas de entrega
   */
  private getOrdersPrediction(): void{
    this.customersService.getPredictionSales().subscribe({
      next: (response) => {
        if(response.result){
          this.sales = response.data;
          this.table = {
            columns : [
            { key: 'companyName', value: 'Customer Name', type: 'text' },
            { key: 'lastOrderDate', value: 'Last Order Date', type: 'date' },
            { key: 'nextPredicterOrder', value: 'Next Predicted Order', type: 'date' },
            ],
            data: this.sales,
            showActions: true
          }
          this.showTable = true;
        }
      }
    })
  }

}
