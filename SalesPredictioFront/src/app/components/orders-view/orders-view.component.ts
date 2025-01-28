import { Component, OnInit, inject } from '@angular/core';
import { OrdersService } from '../../services/orders.service';
import { TableViewModel } from '../../shared/table/Models/TableViewModel';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-orders-view',
  templateUrl: './orders-view.component.html',
  styleUrl: './orders-view.component.css',
})
export class OrdersViewComponent implements OnInit {
  table!: TableViewModel;
  orders!: any[];
  showTable: boolean = false;
  title: string = 'Customers'

  private readonly ordersService = inject(OrdersService);
  readonly data = inject(MAT_DIALOG_DATA);
  readonly dialogRef = inject(MatDialogRef<OrdersViewComponent>);

  ngOnInit(): void {
    this.title = this.data.companyName;
    this.getOrdersCustomer(this.data.custId);
  }

  /**
   * Metodo para obtener todas las ordenes de un cliente
   * 
   * @param custId ID del cliente
   */
  private getOrdersCustomer(custId: string): void {
    this.ordersService.getOrders(custId).subscribe({
      next: (response) => {
        if (response.result) {
          this.orders = response.data;
          this.table = {
            columns: [
              { key: 'orderId', value: 'Order ID', type: 'text' },
              { key: 'requiredDate', value: 'Required Date', type: 'date' },
              { key: 'shippedDate', value: 'Shipped Date', type: 'date' },
              { key: 'shipName', value: 'Ship Name', type: 'text' },
              { key: 'shipAddress', value: 'Ship Address', type: 'text' },
              { key: 'shipCity', value: 'Ship City', type: 'text' },
            ],
            data: this.orders,
            showActions: false,
          };
          this.showTable = true;
        }
      },
    });
  }

  closeTable(): void{
    this.dialogRef.close();
  }
}
