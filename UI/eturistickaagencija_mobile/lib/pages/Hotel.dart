import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

import '../model/hotel.dart';
import '../utils/util.dart';

class HotelListPage extends StatefulWidget {
  const HotelListPage({super.key});

  @override
  // ignore: library_private_types_in_public_api
  _HotelListPageState createState() => _HotelListPageState();
}

class _HotelListPageState extends State<HotelListPage> {
  List<Hotel> hotels = [];

  @override
  void initState() {
    super.initState();
    fetchHotelData();
  }

  Future<void> fetchHotelData() async {
    final response = await http.get(Uri.parse('http://10.0.2.2:5011/api/Hoteli'));

    if (response.statusCode == 200) {
      final data = json.decode(response.body);
      setState(() {
        hotels = List<Hotel>.from(data.map((json) => Hotel.fromJson(json)));
      });
    } else {
      // ignore: use_build_context_synchronously
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Greška'),
            content: const Text('Došlo je do greške prilikom dohvata podataka hotela.'),
            actions: [
              ElevatedButton(
                onPressed: () {
                  Navigator.of(context).pop();
                },
                child: const Text('OK'),
              ),
            ],
          );
        },
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Hoteli'),
      ),
      body: ListView(
        padding: const EdgeInsets.only(top: 16.0), 
        children: [
        
          _buildDataListView(),
        ],
      ),
    );
  }

  Widget _buildDataListView() {
    return SingleChildScrollView(
      child: DataTable(
        dataRowColor: MaterialStateColor.resolveWith((states) => Colors.white), 
        columns: const [
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
                'Brojzvjezdica',
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
          ),
        ],
        rows: hotels.map((Hotel e) {
          return DataRow(cells: [
            DataCell(Text(e.naziv ?? "")),
            DataCell(Text(e.brojZvjezdica?.toString() ?? "")),
            DataCell(e.slika != ""
                ? Container(
                    width: 100,
                    height: 100,
                    color: Colors.white, 
                    child: imageFromBase64String(e.slika!),
                  )
                : const Text("")),
          ]);
        }).toList(),
      ),
    );
  }
}
