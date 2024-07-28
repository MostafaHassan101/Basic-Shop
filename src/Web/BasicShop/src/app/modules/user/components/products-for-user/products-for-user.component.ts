import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/modules/products/services/product.service';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-products-for-user',
  templateUrl: './products-for-user.component.html',
  styleUrls: ['./products-for-user.component.scss']
})
export class ProductsForUserComponent implements OnInit {

  products: Product[] = [];
  searchText: string = '';
  constructor(private productService: ProductService, private cartService: CartService) {

    // this.products = productService.getStaticProducts();
  }

  ngOnInit(): void {
    this.getAllProducts();
  }

  getAllProducts(){
    this.productService.getAllProductsForUser().subscribe({
      next:(data) => {
          this.products = data;
      },
    });
  }

  Search() {
    if (this.searchText.length > 0) {
      this.productService.searchProductsForUser(this.searchText).subscribe({
        next:(data: Product []) => {
            this.products = data;
        },
      })
    }
    else
      this.getAllProducts();
  }

  AddToCart(id: string) 
  {
    console.log(id);
    this.cartService.addItemToCart(id).subscribe({
      next: () => {
          /// notify
          this.getCNewCartItems();
      },
    })
  }

  getCNewCartItems() {
    this.cartService.getCartItems().subscribe({
      next: (data: any) => {
        this.cartService.notifyAddToCart(data);
      },
    });
  }
}
