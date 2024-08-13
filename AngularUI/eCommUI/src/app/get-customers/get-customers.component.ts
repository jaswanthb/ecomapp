import { Component, OnInit } from '@angular/core';
import { CustomerServiceService } from '../services/customer-service.service';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faTrash,faEdit } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-get-customers',
  standalone: true,
  imports: [FontAwesomeModule],
  templateUrl: './get-customers.component.html',
  styleUrl: './get-customers.component.css'
})
export class GetCustomersComponent implements OnInit {
  constructor(private customerService: CustomerServiceService){}
  faTrash = faTrash;
  faEdit = faEdit;
  customers: any[] = [];
  responseMsg: any={};
  showGrid:boolean=false;
  public ngOnInit(): void 
  {
  this.getCustomers();
  }

  getCustomers(){
    this.customerService.getCustomers().subscribe(data => {
      this.customers = data as any[];
      this.showGrid=true;
    });
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

