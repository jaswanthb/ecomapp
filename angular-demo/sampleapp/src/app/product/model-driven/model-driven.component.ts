import { JsonPipe, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { producerAccessed } from '@angular/core/primitives/signals';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-model-driven',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf],
  templateUrl: './model-driven.component.html',
  styleUrl: './model-driven.component.css'
})
export class ModelDrivenComponent {
  frm: FormGroup;
  constructor(private fb: FormBuilder) {
    this.frm = this.fb.group({
      productId: this.fb.control(''),
      productCode: this.fb.control('', [Validators.required]),
      productName: this.fb.control('', [Validators.required, Validators.pattern('^[a-zA-A0-9 ]+$')]),
      price: this.fb.control('')
    });
  }

  saveProduct() {
    if (this.frm.valid) {
      let data = JSON.stringify(this.frm.value);
      alert('Product Saved Successfully.' + data);
    }
    else{
      alert("Validation error");
    }
  }
  disableValidation(){
    //Find product element
    let productNameCtrl = this.frm.get('productName');

    //clear validation
    productNameCtrl?.clearValidators();

    //Add validator
    //let productCodeCtrl = this.frm.get('productCode');
    //productNameCtrl?.setValidators([Validators.minLength(2)]) 

    //Update form
    productNameCtrl?.updateValueAndValidity();
  }

}
