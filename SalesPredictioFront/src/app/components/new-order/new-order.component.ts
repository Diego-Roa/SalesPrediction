import { Component, OnInit, inject } from '@angular/core';
import { OrdersService } from '../../services/orders.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeesService } from '../../services/employees.service';
import { Employees } from '../../interfaces/Employees';
import { Shippers } from '../../interfaces/Shippers';
import { Products } from '../../interfaces/Products';
import { ShippersService } from '../../services/shippers.service';
import { ProductsService } from '../../services/products.service';

@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrl: './new-order.component.css'
})
export class NewOrderComponent implements OnInit{

  orderForm!: FormGroup;
  employees!: Employees[];
  shippers!: Shippers[];
  products!: Products[];
  customerName: string = '';
  custId: string = '';

  private readonly ordersService = inject(OrdersService);
  readonly data = inject(MAT_DIALOG_DATA);
  readonly dialogRef = inject(MatDialogRef<NewOrderComponent>);
  private readonly formBuilder = inject(FormBuilder);
  private readonly employeesService = inject(EmployeesService);
  private readonly shipperService = inject(ShippersService);
  private readonly productService = inject(ProductsService);

  ngOnInit(): void {
    this.customerName = this.data.companyName;
    this.formInit(this.data.custId);
    this.getEmployees();
    this.getShippers();
    this.getProducts();
  }

  formInit(custId: string){
    this.orderForm = this.formBuilder.group({
      custId: [custId, [Validators.required]],
      empId: ['', [Validators.required]],
      shipperId: ['', [Validators.required]],
      shipName: ['', [Validators.required]],
      shipAddress: ['', [Validators.required]],
      shipCity: ['', [Validators.required]],
      shipCountry: ['', [Validators.required]],
      orderDate: ['', [Validators.required]],
      requiredDate: ['', [Validators.required]],
      shippedDate: ['', [Validators.required]],
      freight: ['', [Validators.required]],
      productId: ['', [Validators.required]],
      unitPrice: ['', [Validators.required]],
      qty: ['', [Validators.required]],
      discount: ['', [Validators.required]],
    })
  }

  getProducts(): void {
    this.productService.getProducts().subscribe({
      next: (response) => {
        if(response.result){
          this.products = response.data as Products[];
        }
      }
    })
  }

  getEmployees(): void {
    this.employeesService.getEmployees().subscribe({
      next: (response) => {
        if (response.result) {
          this.employees = response.data as Employees[];
        }
      }
    })
  }

  getShippers(): void {
    this.shipperService.getShippers().subscribe({
      next: (response) => {
        if (response.result) {
          this.shippers = response.data as Shippers[];
        }
      },
    })
  }

  addOrder(): void{
    if(this.orderForm.valid){
      this.ordersService.addNewOrder(this.orderForm.value).subscribe({
        next: (response) => {
          if (response.result) {
            this.dialogRef.close(response.result)
          }
        }
      })
    }
  }

  closeForm(): void{
    this.dialogRef.close()
  }

}
