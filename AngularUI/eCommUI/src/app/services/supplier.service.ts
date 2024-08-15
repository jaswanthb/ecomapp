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

  getSupplierById(id: number)
  {
    return this.httpClient.get("https://localhost:7056/api/Suppliers/suppliers/"+id);
  }

  insertSupplier(payload: any) {
    return this.httpClient.post("https://localhost:7056/api/Suppliers/suppliers",payload)
  }

  updateSupplier(payload: any){
    return this.httpClient.put("https://localhost:7056/api/Suppliers/suppliers",payload)
  }
  deleteSupplier(payload: any){
    return this.httpClient.delete("https://localhost:7056/api/Suppliers/suppliers?supplierId="+payload)
  }
}
