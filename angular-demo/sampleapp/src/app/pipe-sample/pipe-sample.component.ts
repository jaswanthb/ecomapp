import { Component, inject } from '@angular/core';
import { Product } from '../Models/product';
import { CommonModule } from '@angular/common';
import { MypipePipe } from '../custom/mypipe.pipe';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-pipe-sample',
  standalone: true,
  imports: [CommonModule, MypipePipe, RouterModule],
  templateUrl: './pipe-sample.component.html',
  styleUrl: './pipe-sample.component.css'
})
export class PipeSampleComponent {
  product: Product;
  Dob: Date;

  router = inject(Router);

  ar = inject(ActivatedRoute);


  constructor(private activatedR: ActivatedRoute) {
    this.product = new Product(101, "Laptop", "P001", 45000);
    this.Dob = new Date();

    //this.ar.params(
  }

  navigateToDirective() {
    //this.router.navigate(['dir', this.product.productId]) // To pass route paramters only
    this.router.navigate(['dir', this.product.productId], {queryParams:{
      city:"hyd",
      country:"india"
    }}) // To pass route params and query params
  }
}
