import 'package:myapp/model/hotel.dart';


class Cart {
    List<CartItem> items = [];
}

class CartItem {
  CartItem(this.hotel, this.count);
  late Hotel hotel;
  late int count;
}