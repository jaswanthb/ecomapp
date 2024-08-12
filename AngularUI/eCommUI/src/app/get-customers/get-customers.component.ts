import { Component } from '@angular/core';
import { CustomerServiceService } from '../services/customer-service.service';

@Component({
  selector: 'app-get-customers',
  standalone: true,
  imports: [],
  templateUrl: './get-customers.component.html',
  styleUrl: './get-customers.component.css'
})
export class GetCustomersComponent {
  constructor(private customerService: CustomerServiceService){}

  customers: any[] = [];
  responseMsg: any={};

  getCustomers(){
    //debugger;
    var res = this.customerService.getCustomers().subscribe(data => {
      this.customers = data as any[];
      console.log("custResponse",this.customers);
    });
    console.log("res",res);
    //show some edit btn/deletes
  }
  insertCustomer()
  {
    var payload = 
    {
      "customerID": 94,
      "customerCode": "AAASA",
      "companyName": "TCS",
      "contactName": "Aravind",
      "contactTitle": "Aravind",
      "address": "Kondapur",
      "city": "Hyderabad",
      "region": "string",
      "postalCode": "string",
      "country": "string",
      "phone": "string",
      "fax": "string",
      "isActive": true
    };
    this.customerService.insertCustomer(payload).subscribe(data => {
    this.responseMsg=data as RespMsg;
    if(this.responseMsg.isError == false){
      alert("Customer Inserted Successfully");
    }
    else{
      alert("Something Went Wrong " + this.responseMsg.errorMessage);
    }
    });
  }
  updateCustomer(){
    var payload = 
    {
  "customerID": 93,
  "customerCode": "string",
  "companyName": "string",
  "contactName": "string",
  "contactTitle": "string",
  "address": "string",
  "city": "string",
  "region": "string",
  "postalCode": "string",
  "country": "string",
  "phone": "string",
  "fax": "string",
  "isActive": true
    };
    this.customerService.updateCustomer(payload).subscribe(data => {
      this.responseMsg=data as RespMsg;
      if(this.responseMsg.isError == false){
        alert("Customer Updated Successfully");
      }
      else{
        alert("Something Went Wrong " + this.responseMsg.errorMessage);
      }
    });
  }

  deleteCustomer(){
    this.customerService.deleteCustomer('string1').subscribe(data => {
      this.responseMsg=data as RespMsg
      if(this.responseMsg.isError == false){
          alert("Customer Deleted Successfully");
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

