import { Component } from '@angular/core';
import { Product } from '../../Models/product';
import { FormsModule, NgForm } from '@angular/forms';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-template-driven',
  standalone: true,
  imports: [FormsModule, NgIf],
  templateUrl: './template-driven.component.html',
  styleUrl: './template-driven.component.css'
})
export class TemplateDrivenComponent {
product: Product;

constructor() {
  this.product = new Product();  
}

SaveProduct(frm:NgForm){
  if(frm.valid){
    //call api
    alert('Product Saved successfully');

  }
  else{
    alert('Validation error');
  }
}
}
