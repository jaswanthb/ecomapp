import { Component } from '@angular/core';
import { SupplierService } from '../services/supplier.service';

@Component({
  selector: 'app-get-supplier',
  standalone: true,
  imports: [],
  templateUrl: './get-supplier.component.html',
  styleUrl: './get-supplier.component.css'
})
export class GetSupplierComponent {
  constructor(private supplierService : SupplierService){}

  suppliers: any[]=[];
  getSuppliers(){
    this.supplierService.getsupplier().subscribe(data => {
      this.suppliers = data as any[];
      console.log("custResponse",this.suppliers);
    });
  }

}
