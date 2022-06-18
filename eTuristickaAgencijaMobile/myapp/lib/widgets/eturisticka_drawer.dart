import 'package:myapp/models/product.dart';
import 'package:myapp/providers/cart_providers.dart';
import 'package:myapp/screen/products/product_list_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../screen/cart/cart_screen.dart';
import '../screen/destinacije/destinacije_list_screen.dart';
import '../screen/drzave/drzave_list_screen.dart';

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
              
               Navigator.popAndPushNamed(context, ProductListScreen.routeName);
            },
          ),
          ListTile(
            title: Text('Cart ${_cartProvider?.cart.items.length}'),
            onTap: () {
               Navigator.pushNamed(context, CartScreen.routeName);
            },
          ),
           ListTile(
            title: Text('Destinacije'),
            onTap: () {
               Navigator.popAndPushNamed(context, DestinacijeListScreen.routeName);
            },
          ),
           ListTile(
            title: Text('Drzave'),
            onTap: () {
               Navigator.popAndPushNamed(context, DrzaveListScreen.routeName);
            },
          ),
        ],
      ),
    );
  }
}