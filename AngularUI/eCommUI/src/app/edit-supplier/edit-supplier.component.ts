import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router, RouterStateSnapshot } from "@angular/router";
import { SupplierService } from "../services/supplier.service";
import { supplier } from "../models/supplier";

@Component({
    selector: 'app-edit-supplier',
    standalone: true,
    imports: [],
    templateUrl: './edit-supplier.component.html',
    styleUrl: './edit-supplier.component.css'
  })
  export class EditSupplierComponent implements OnInit {

    supId: any;
    supplier: any;
    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private supService: SupplierService
    ){

    }

    ngOnInit() {
        this.supId = this.route.snapshot.paramMap.get('companyName');
        if(this.supId == null){
            alert("New Supplier")
        }
        else{
            this.supService.getSupplierById(this.supId).subscribe(data =>{
                this.supplier = data as supplier;
                debugger;
            });
        }
    }
    updateSupplier(){

        this.supService.insertSupplier(this.supplier);
    }
  }