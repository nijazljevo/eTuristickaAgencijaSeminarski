import 'package:myapp/providers/drzave_provider.dart';
import 'package:myapp/screen/products/product_details_screen.dart';
import 'package:myapp/utils/util.dart';
import 'package:myapp/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../../models/drzave.dart';
import '../../widgets/eturisticka_drawer.dart';
import 'drzave_details_screen.dart';

class DrzaveListScreen extends StatefulWidget {
  static const String routeName = "/drzave";

  const DrzaveListScreen({Key? key}) : super(key: key);

  @override
  State<DrzaveListScreen> createState() => _DrzaveListScreenState();
}

class _DrzaveListScreenState extends State<DrzaveListScreen> {
  DrzaveProvider? _drzaveProvider = null;
  List<Drzave> data = [];
  TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _drzaveProvider = context.read<DrzaveProvider>();
    print("called initState");
    loadData();
  }

  Future loadData() async {
    var tmpData = await _drzaveProvider?.get(null);
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
              _buildProductSearch(),
              Container(
                height: 200,
                child: GridView(
                  gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                      crossAxisCount: 1,
                      childAspectRatio: 4 / 3,
                      crossAxisSpacing: 20,
                      mainAxisSpacing: 30),
                  scrollDirection: Axis.horizontal,
                  children: _buildProductCardList(),
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
      child: Text("Drzave", style: TextStyle(color: Colors.grey, fontSize: 40, fontWeight: FontWeight.w600),),
    );
  }

  Widget _buildProductSearch() {
    return Row(
      children: [
        Expanded(
          child: Container(
            padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
            child: TextField(
              controller: _searchController,
              onSubmitted: (value) async {
                var tmpData = await _drzaveProvider?.get({'naziv': value});
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
                var tmpData = await _drzaveProvider?.get({'naziv': _searchController.text});
                setState(() {
                  data = tmpData!;
                });
            },
          ),
        )
      ],
    );
  }


  List<Widget> _buildProductCardList() {
    if (data.length == 0) {
      return [Text("Loading...")];
    }

    List<Widget> list = data
        .map((x) => Container(
              
              child: Column(
                children: [
                  InkWell(
                    onTap: () {
                      Navigator.pushNamed(context, "${DrzaveDetailsScreen.routeName}/${x.drzavaId}");
                    },
                    
                  ),
                  Text(x.naziv ?? ""),
                 
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }
}