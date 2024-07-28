import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  cartItems: any[] = [];
  total: any;
  // cartItems = [
  //   { name: 'Cash Money Gun', price: 43.0, quantity: 3 }
  // ];

  // get total(): number {
  //   return this.cartItems.reduce((sum, item) => sum + item.price * item.quantity, 0);
  // }
  constructor(private cartService: CartService) {

  }

  ngOnInit(): void {
    /// get cart items
    this.getCartItems();

    /// get new items when new item added
    this.getNewItems();
  }

  updateItemInCart(itemId: string, qty: number) {
    this.cartService.updateCartItem(itemId, qty).subscribe({
      next: (value) => {
        ///
      },
    })
  }

  getCartItems() {
    this.cartService.getCartItems().subscribe({
      next: (data: any) => {
        this.cartItems = data.items;
        this.total = data.total;
      },
    });
  }

  getNewItems() {
    this.cartService.getNotification().subscribe({
      next: (data: any) => {
        if (data != null) {
          this.cartItems = data.items;
          this.total = data.total;
        }
      },
    });
  }

  onValueChange(itemId: string, quantity: any) {
    console.log(itemId, quantity);

    this.updateItemInCart(itemId, quantity);

  }

}
