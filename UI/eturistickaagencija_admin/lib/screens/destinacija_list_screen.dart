import 'dart:convert';
import 'dart:math';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import '../models/grad.dart';
import '../utils/util.dart';
import 'destinacija_details_screen.dart';

class DestinacijaListScreen extends StatefulWidget {
  @override
  _DestinacijaListScreenState createState() => _DestinacijaListScreenState();
}

class _DestinacijaListScreenState extends State<DestinacijaListScreen> {
  List<Drzava> drzave = [];
  List<Kontinent> kontinenti = [];
  List<Grad> grad = [];
  List<Destinacija> destinacija = [];

  @override
  void initState() {
    super.initState();
  }


    

  Future<void> searchDestinacije(String naziv,int gradId,int drzavaId, int kontinentId) async {
    try {
      final url = 'http://localhost:5011/api/Destinacije?naziv=$naziv&gradId=$gradId&drzavaId=$drzavaId&kontinentId=$kontinentId';
      final response = await http.get(Uri.parse(url));

      if (response.statusCode == 200) {
        final List<dynamic> responseData = json.decode(response.body);
        destinacija = responseData.map((data) {
          return Destinacija(
            id: data['id'],
            naziv: data['naziv'],
            slika: data['slika'],
          );
        }).toList();
      } else {
        throw Exception('Failed to fetch destinacija');
      }
    } catch (error) {
      print(error);
    }

    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Destinacije'),
      ),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              children: [
                Expanded(
                  child: TextField(
                    decoration: InputDecoration(
                      labelText: 'Naziv',
                    ),
                    onChanged: (value) {
                      // Update the search query when the text field value changes
                      setState(() {
                        searchDestinacije(value,0, 0,0); // Assuming kontinentId is 0 for all drzave
                      });
                    },
                  ),
                ),
                SizedBox(width: 8),
                DropdownButton<Kontinent>(
                  value: kontinenti.isNotEmpty ? kontinenti[0] : null,
                  onChanged: (value) {
                    // Handle dropdown value change
                    // You may store the value in a variable and use it for searching
                  },
                  items: kontinenti.map((kontinent) {
                    return DropdownMenuItem<Kontinent>(
                      value: kontinent,
                      child: Text(kontinent.naziv),
                    );
                  }).toList(),
                ),
                SizedBox(width: 8),
                ElevatedButton(
                  onPressed: () {
                    // Handle search button click
                    // You can use the entered values to search for drzave
                    String naziv = ''; // Get the entered value from the text field
                    int kontinentId = 0;
                    int drzavaId = 0;
                    int gradId = 0; // Get the selected value from the dropdown
                    searchDestinacije(naziv,gradId,drzavaId, kontinentId);
                  },
                  child: Text('Pretraga'),

                ),
                SizedBox(width: 8,),
                  ElevatedButton(onPressed: ()async {
                    
                         Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) =>  DestinacijaDetailsScreen(),
                          ),
                        );
                     
                  }, child: Text("Dodaj"))
              ],
            ),
          ),
          Expanded(
            child: DataTable(
              columns: const [
                DataColumn(label: Text('ID')),
                DataColumn(label: Text('Naziv')),
                DataColumn(label: Text('Slika')),
              ],
            rows: destinacija
                  .map(
                    (Destinacija e) => DataRow(
                      onSelectChanged: (selected) {
                        if (selected == true) {
                          Navigator.of(context).push(
                            MaterialPageRoute(
                              builder: (context) => DestinacijaDetailsScreen(destinacija: e),
                            ),
                          );
                        }
                      },
                      cells: [
                        DataCell(Text(e.id?.toString() ?? "")),
                        DataCell(Text(e.naziv ?? "")),
                         DataCell(e.slika != null && e.slika != ""
  ? Container(
      width: 100,
      height: 100,
      child: imageFromBase64String(e.slika!),
    )
  : Text(""))

                      ],
                    ),
                  )
                  .toList() ??
              [],
            ),
          ),
        ],
      ),
    );
  }
}
// class Destinacija{
//   final int id;
//   final String naziv;
//   final String slika;

//   Destinacija({
//     required this.id,
//     required this.naziv,
//     required this.slika,
//   });
// }
class Grad {
  final int id;
  final String naziv;

  Grad({
    required this.id,
    required this.naziv,
  });
}
class Drzava {
  final int id;
  final String naziv;

  Drzava({
    required this.id,
    required this.naziv,
  });
}

class Kontinent {
  final int id;
  final String naziv;

  Kontinent({
    required this.id,
    required this.naziv,
  });
}


