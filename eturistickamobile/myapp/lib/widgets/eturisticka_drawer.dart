import 'package:myapp/model/hotel.dart';
import 'package:myapp/providers/cart_provider.dart';
import 'package:myapp/screens/hoteli/hoteli_list_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../screens/cart/cart_screen.dart';

class eTuristickaDrawer extends StatelessWidget {
  eTuristickaDrawer({Key? key}) : super(key: key);
  CartProvider? _cartProvider;
  @override
  Widget build(BuildContext context) {
    _cartProvider = context.watch<CartProvider>();
    print("called build drawer");
    return Drawer(
      child: ListView(
        children: [
          
          ListTile(
            title: Text('Home'),
            onTap: () {
              
               Navigator.popAndPushNamed(context, HotelListScreen.routeName);
            },
          ),
          ListTile(
            title: Text('Cart ${_cartProvider?.cart.items.length}'),
            onTap: () {
               Navigator.pushNamed(context, CartScreen.routeName);
            },
          ),
         
        ],
      ),
    );
  }
}