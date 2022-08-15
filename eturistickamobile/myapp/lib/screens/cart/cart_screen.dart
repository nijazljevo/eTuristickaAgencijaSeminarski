import 'package:myapp/model/cart.dart';
import 'package:myapp/providers/cart_provider.dart';
import 'package:myapp/widgets/eturisticka_drawer.dart';
import 'package:myapp/widgets/master_screen.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../../utils/util.dart';

class CartScreen extends StatefulWidget {
  static const String routeName = "/cart";

  const CartScreen({Key? key}) : super(key: key);

  @override
  State<CartScreen> createState() => _CartScreenState();
}

class _CartScreenState extends State<CartScreen> {

  late CartProvider _cartProvider;
  
  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    
  }

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();
    _cartProvider = context.watch<CartProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
        child: Column(
          children: [
            Expanded(child:_buildHotelCardList()),
            _buildBuyButton(),
          ],
        ),
      );
  }

  Widget _buildHotelCardList() {
    return Container(
      child: ListView.builder(
        itemCount: _cartProvider.cart.items.length,
        itemBuilder: (context, index) {
          return _buildHotelCard(_cartProvider.cart.items[index]);
        },
      ),
    );
  }

  Widget _buildHotelCard(CartItem item) {
    return ListTile(
      leading: imageFromBase64String(item.hotel.slika!),
      title: Text(item.hotel.naziv ?? ""),
      subtitle: Text(item.hotel.brojZvijezdica.toString()),
      trailing: Text(item.count.toString()),
    );
  }

  Widget _buildBuyButton() {
    return TextButton(
      child: Text("Buy"),
      onPressed: () async {
        List<Map> items = [];
        _cartProvider.cart.items.forEach((item) {
          items.add({
            "hotelId": item.hotel.hotelId,
            "kolicina": item.count,
          });
        });
        Map destinacija = {
          "items": items,
        };
       


        _cartProvider.cart.items.clear();
        setState(() {
        });
      },
    );
  }
}