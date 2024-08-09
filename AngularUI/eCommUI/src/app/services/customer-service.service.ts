import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {

  constructor(private httpClient: HttpClient) { }

  getCustomers(){
    return this.httpClient.get("https://localhost:7056/api/Customer/customers?searchParam=a");
  }

  insertCustomer(payload: any){
    return this.httpClient.post('https://localhost:7056/api/Customer/customers',payload);
  }
  
}
