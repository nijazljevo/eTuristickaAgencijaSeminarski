import 'package:myapp/providers/hoteli_provider.dart';
import 'package:myapp/screens/cart/cart_screen.dart';
import 'package:myapp/screens/hoteli/hoteli_details_screen.dart';
import 'package:myapp/utils/util.dart';
import 'package:myapp/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../../model/hotel.dart';
import '../../providers/cart_provider.dart';
import '../../widgets/eturisticka_drawer.dart';

class HotelListScreen extends StatefulWidget {
  static const String routeName = "/hoteli";

  const HotelListScreen({Key? key}) : super(key: key);

  @override
  State<HotelListScreen> createState() => _HotelListScreenState();
}

class _HotelListScreenState extends State<HotelListScreen> {
  HotelProvider? _hotelProvider = null;
  CartProvider? _cartProvider = null;
  List<Hotel> data = [];
  TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _hotelProvider = context.read<HotelProvider>();
    _cartProvider = context.read<CartProvider>();
    print("called initState");
    loadData();
  }

  Future loadData() async {
    var tmpData = await _hotelProvider?.get(null);
    setState(() {
      data = tmpData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    print("called build $data");
    return MasterScreenWidget(
      child: SingleChildScrollView(
        child: Container(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              _buildHeader(),
              _buildHotelSearch(),
              Container(
                height: 200,
                child: GridView(
                  gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                      crossAxisCount: 1,
                      childAspectRatio: 4 / 3,
                      crossAxisSpacing: 20,
                      mainAxisSpacing: 30),
                  scrollDirection: Axis.horizontal,
                  children: _buildHotelCardList(),
                ),
              )
            ],
          ),
        ),
      )
    );
  }

  Widget _buildHeader() {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
      child: Text("Hoteli", style: TextStyle(color: Colors.grey, fontSize: 40, fontWeight: FontWeight.w600),),
    );
  }

  Widget _buildHotelSearch() {
    return Row(
      children: [
        Expanded(
          child: Container(
            padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
            child: TextField(
              controller: _searchController,
              onSubmitted: (value) async {
                var tmpData = await _hotelProvider?.get({'naziv': value});
                setState(() {
                  data = tmpData!;
                });
              },
              decoration: InputDecoration(
                  hintText: "Search",
                  prefixIcon: Icon(Icons.search),
                  border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(10),
                      borderSide: BorderSide(color: Colors.grey))),
            ),
          ),
        ),
        Container(
          padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
          child: IconButton(
            icon: Icon(Icons.filter_list),
            onPressed: () async {
                var tmpData = await _hotelProvider?.get({'naziv': _searchController.text});
                setState(() {
                  data = tmpData!;
                });
            },
          ),
        )
      ],
    );
  }


  List<Widget> _buildHotelCardList() {
    if (data.length == 0) {
      return [Text("Loading...")];
    }

    List<Widget> list = data
        .map((x) => Container(
              
              child: Column(
                children: [
                  InkWell(
                    onTap: () {
                      Navigator.pushNamed(context, "${HotelDetailsScreen.routeName}/${x.hotelId}");
                    },
                    child: Container(
                      height: 100,
                      width: 100,
                      child: imageFromBase64String(x.slika!),
                    ),
                  ),
                  Text(x.naziv ?? ""),
                  IconButton(
                    icon: Icon(Icons.shopping_cart),
                    onPressed: ()  {
                        _cartProvider?.addToCart(x);
                    },
                  )
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }
}