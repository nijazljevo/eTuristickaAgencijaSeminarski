import 'package:collection/collection.dart';
import 'package:myapp/model/cart.dart';
import 'package:flutter/widgets.dart';

import '../model/hotel.dart';

class CartProvider with ChangeNotifier {
  Cart cart = Cart();
  addToCart(Hotel hotel) {
    if (findInCart(hotel) != null) {
      findInCart(hotel)?.count++;
    } else {
      cart.items.add(CartItem(hotel, 1));
    }
    
    notifyListeners();
  }

  removeFromCart(Hotel hotel) {
    cart.items.removeWhere((item) => item.hotel.hotelId == hotel.hotelId);
    notifyListeners();
  }

  CartItem? findInCart(Hotel hotel) {
    CartItem? item = cart.items.firstWhereOrNull((item) => item.hotel.hotelId == hotel.hotelId);
    return item;
  }
}