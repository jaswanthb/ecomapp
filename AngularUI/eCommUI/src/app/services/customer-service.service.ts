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

  getCustomerById(id: number){
    return this.httpClient.get("https://localhost:7056/api/Customer/customers/"+id);
  }

  insertCustomer(payload: any){
    return this.httpClient.post('https://localhost:7056/api/Customer/customers',payload);
  }
  updateCustomer(payload: any){
    return this.httpClient.put('https://localhost:7056/api/Customer/customers',payload);
  }
  deleteCustomer(payload: string){
    return this.httpClient.delete('https://localhost:7056/api/Customer/customers?customerCode='+payload);
  }
    
}
