
import 'package:eturistickaagencija_admin/providers/hotel_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/hotel.dart';
import '../models/search_result.dart';
import '../utils/util.dart';
import '../widgets/master_screen.dart';
import 'hotel_details_screen.dart';

class HotelListScreen extends StatefulWidget {
  const HotelListScreen({Key? key}) : super(key: key);

  @override
  State<HotelListScreen> createState() => _HotelListScreenState();
}

class _HotelListScreenState extends State<HotelListScreen> {
  late HotelProvider _hotelProvider;
  SearchResult<Hotel>? result;
  // ignore: prefer_final_fields, unnecessary_new
  TextEditingController _nazivController = new TextEditingController();
  
  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();
    _hotelProvider = context.read<HotelProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title_widget: const Text("Hotel list"),
      // ignore: avoid_unnecessary_containers
      child: Container(
        child: Column(children: [_buildSearch(), _buildDataListView()]),
      ),
    );
  }

  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Row(
        children: [
          Expanded(
            child: TextField(
              decoration: const InputDecoration(labelText: "Naziv"),
              controller: _nazivController,
            ),
          ),
          const SizedBox(
            width: 8,
          ),
         
          ElevatedButton(
              onPressed: () async {
                // ignore: avoid_print
                print("login proceed");

                var data = await _hotelProvider.get(filter: {
                  'naziv': _nazivController.text,
                });

                setState(() {
                  result = data;
                });

              },
              child: const Text("Pretraga")),
          const SizedBox(
            width: 8,
          ),
          ElevatedButton(
              onPressed: () async {
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) =>  HotelDetailsScreen(
                     hotel: null,
                    ),
                  ),
                );
              },
              child: const Text("Dodaj"))
        ],
      ),
    );
  }

  Widget _buildDataListView() {
    return Expanded(
        child: SingleChildScrollView(
      child: DataTable(
          columns: const [
            DataColumn(
              label: Expanded(
                child: Text(
                  'ID',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
           
            DataColumn(
              label: Expanded(
                child: Text(
                  'Naziv',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
             DataColumn(
              label: Expanded(
                child: Text(
                  'Broj zvjezdica',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
           
            DataColumn(
              label: Expanded(
                child: Text(
                  'Slika',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            )
          ],
          rows: result?.result
                  .map((Hotel e) => DataRow(
                          onSelectChanged: (selected) => {
                                if (selected == true)
                                  {
                                    Navigator.of(context).push(
                                      MaterialPageRoute(
                                        builder: (context) =>
                                            HotelDetailsScreen(
                                          hotel: e,
                                        ),
                                      ),
                                    )
                                  }
                              },
                          cells: [
                            DataCell(Text(e.id?.toString() ?? "")),
                            DataCell(Text(e.naziv ?? "")),
                            DataCell(Text(e.brojZvjezdica?.toString() ?? "")),
                            DataCell(e.slika != ""
                                // ignore: sized_box_for_whitespace
                                ? Container(
                                    width: 100,
                                    height: 100,
                                    child: imageFromBase64String(e.slika!),
                                  )
                                : const Text(""))
                          ]))
                  .toList() ??
              []),
    ));
  }
}