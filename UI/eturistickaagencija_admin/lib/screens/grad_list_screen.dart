import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;


import 'grad_details_screen.dart';

class GradoviScreen extends StatefulWidget {
  @override
  _GradoviScreenState createState() => _GradoviScreenState();
}

class _GradoviScreenState extends State<GradoviScreen> {
  List<Drzava> drzave = [];
  List<Kontinent> kontinenti = [];
  List<Grad> grad = [];
  

  @override
  void initState() {
    super.initState();
  }


    

  Future<void> searchGradovi(String naziv,int drzavaId, int kontinentId) async {
    try {
      final url = 'http://localhost:5011/api/Gradovi?naziv=$naziv&drzavaId=$drzavaId&kontinentId=$kontinentId';
      final response = await http.get(Uri.parse(url));

      if (response.statusCode == 200) {
        final List<dynamic> responseData = json.decode(response.body);
        grad = responseData.map((data) {
          return Grad(
            id: data['id'],
            naziv: data['naziv'],
          );
        }).toList();
      } else {
        throw Exception('Failed to fetch grad');
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
        title: Text('Gradovi'),
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
                        searchGradovi(value, 0,0); // Assuming kontinentId is 0 for all drzave
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
                    int drzavaId = 0; // Get the selected value from the dropdown
                    searchGradovi(naziv,drzavaId, kontinentId);
                  },
                  child: Text('Pretraga'),
                  
                ),
                SizedBox(width: 8,),
                  ElevatedButton(onPressed: ()async {
                    
                         Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) =>  DodavanjeGradaScreen(),
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
              ],
             rows: grad
                  .map(
                    (Grad e) => DataRow(
                      onSelectChanged: (selected) {
                        if (selected == true) {
                          Navigator.of(context).push(
                            MaterialPageRoute(
                              builder: (context) => DodavanjeGradaScreen(grad: e as Grad),
                            ),
                          );
                        }
                      },
                      cells: [
                        DataCell(Text(e.id?.toString() ?? "")),
                        DataCell(Text(e.naziv ?? "")),
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
// class Grad {
//   final int id;
//   final String naziv;

//   Grad({
//     required this.id,
//     required this.naziv,
//   });
// }
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

