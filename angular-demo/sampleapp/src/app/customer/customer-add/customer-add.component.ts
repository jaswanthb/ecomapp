import { CommonModule } from '@angular/common';
import { Component, ElementRef, Pipe, ViewChild } from '@angular/core';
import { CustomerListComponent } from '../customer-list/customer-list.component';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-customer-add',
  standalone: true,
  imports: [CommonModule, CustomerListComponent, FormsModule],
  templateUrl: './customer-add.component.html',
  styleUrl: './customer-add.component.css'
})
export class CustomerAddComponent {
  customerName: string | undefined;
  customers: string[];

  @ViewChild('custlistviewchild')
  customerListComponent: CustomerListComponent | undefined;

  @ViewChild('divMessage')
  div: ElementRef | undefined;

  constructor() {
    this.customers = [];
  }
  addCustomer() {
    this.customers.push(this.customerName ?? ""); // input decorator

    this.customerListComponent?.customers?.push(this.customerName ?? "");
    this.customerListComponent?.prod?.push("abc");

    if (this.div != undefined) {
      this.div.nativeElement.innerText = "Customer Added";
      setTimeout(() => {
        if(this.div !=undefined){
          this.div.nativeElement.innerText = "";
        }
      }, 2000);
    }

  }
  selectedCustomer(cust: string) {
    this.customerName = cust;
  }
}
