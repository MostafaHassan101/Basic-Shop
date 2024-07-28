import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ApiClientService } from '../../../services/api-client.service';

const baseEndpoint = 'api/cart';
@Injectable({
    providedIn: 'root'
})
export class CartService {
    private cartEndpoints = 'api/cart';

    private notifyAddItemToCart = new BehaviorSubject<any>(null);
    constructor(private apiClientService: ApiClientService) { }

    getCartItems(){
        return this.apiClientService.get<any>(this.cartEndpoints);
    }

    addItemToCart(itemId: string, quantity: number = 1){
        return this.apiClientService.post<any>(`${this.cartEndpoints}`, {productId: itemId, quantity: quantity});
    }

    updateCartItem(itemId: string, quantity: number){
        return this.apiClientService.put<any>(`${this.cartEndpoints}`, {id: itemId, quantity: quantity});
    }


    notifyAddToCart(succeeded: boolean = true) {
        this.notifyAddItemToCart.next(succeeded)
    }
    
    getNotification() {
        return this.notifyAddItemToCart.asObservable();
    }

}
