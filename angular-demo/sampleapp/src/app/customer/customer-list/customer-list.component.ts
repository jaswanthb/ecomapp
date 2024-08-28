import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-customer-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './customer-list.component.html',
  styleUrl: './customer-list.component.css'
})
export class CustomerListComponent {
  @Input('customers')
  customers: string[] | undefined;

  @Output('on-selection')
  onSelect: EventEmitter<string>;

  constructor() {
    this.customers = [];
    this.onSelect = new EventEmitter<string>();
  }

  selectCustomer(cust: string) {
    this.onSelect.emit(cust);
  }
}
