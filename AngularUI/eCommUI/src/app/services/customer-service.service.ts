import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {

  constructor(private httpClient: HttpClient) { }

  getCustomers(){
    return this.httpClient.get("https://jsonplaceholder.typicode.com/users");
  }

  insertCustomer(payload: any){
    return this.httpClient.post("https://jsonplaceholder.typicode.com/users",payload);
  }
}
