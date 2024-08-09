import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  constructor(private httpClient: HttpClient) { }

  getsupplier()
  {
      return this.httpClient.get("https://localhost:7056/api/Suppliers/suppliers?searchQuery=a")  
  }
}
