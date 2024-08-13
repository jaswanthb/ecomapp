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
  responseMsg: any={};

  getSuppliers(){
    this.supplierService.getsupplier().subscribe(data => {
      this.suppliers = data as any[];
      console.log("custResponse",this.suppliers);
    });
  }
  insertSupplier(){
    var payload = 
    {
      "supplierID": 0,
  "companyName": "AAAA",
  "contactName": "AAAAA",
  "contactTitle": "sg",
  "address": "strng",
  "city": "strg",
  "region": "string",
  "postalCode": "string",
  "country": "string",
  "phone": "sting",
  "fax": "string",
  "homePage": "string",
  "isActive": true
    };
    this.supplierService.insertSupplier(payload).subscribe(data => {
      this.responseMsg=data as RespMsg;
      if(this.responseMsg.isError == false){
        alert("Supplier Inserted Successfully");
      }
      else{
        alert("Something Went Wrong " + this.responseMsg.errorMessage);
      }
    });
  }

  updateSupplier(){
    var payload =
    {
      "supplierID": 31,
      "companyName": "AAAvvv",
      "contactName": "string",
      "contactTitle": "string",
      "address": "string",
      "city": "string",
      "region": "string",
      "postalCode": "string",
      "country": "string",
      "phone": "string",
      "fax": "string",
      "homePage": "string",
      "isActive": true
    };
    this.supplierService.updateSupplier(payload).subscribe(data => {
      this.responseMsg=data as RespMsg;
      if(this.responseMsg.isError == false){
        alert("Supplier Updated Succesfully");
      }
      else{
        alert("Something Went Wrong " + this.responseMsg.errorMessage);
      }
    });
  }

  deleteSupplier(){
    this.supplierService.deleteSupplier(32).subscribe(data => {
      this.responseMsg=data as RespMsg
      if(this.responseMsg.isError == false){
        alert("Supplier Deleted Successfully");
      }
      else{
        alert("Something Went Wrong "+ this.responseMsg.errorMessage)
      }
    });
  }
}

export interface RespMsg 
{
  isError:boolean;
  errorMessage:string;
}