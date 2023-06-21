import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'drzava_details_screen.dart';

class DrzavaListScreen extends StatefulWidget {
  @override
  _DrzavaListScreennState createState() => _DrzavaListScreennState();
}

class _DrzavaListScreennState extends State<DrzavaListScreen> {
  List<Drzava> drzave = [];
  List<Kontinent> kontinenti = [];
  
  @override
  void initState() {
    super.initState();
  }

  Future<void> searchDrzave(String naziv, int kontinentId) async {
    try {
      final url = 'http://localhost:5011/api/Drzave?naziv=$naziv&kontinentId=$kontinentId';
      final response = await http.get(Uri.parse(url));
      if (response.statusCode == 200) {
        final List<dynamic> responseData = json.decode(response.body);
        drzave = responseData.map((data) {
          return Drzava(
            id: data['id'],
            naziv: data['naziv'],
          );
        }).toList();
      } else {
        throw Exception('Failed to fetch drzava');
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
        title: Text('Drzave'),
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
                      setState(() {
                        searchDrzave(value, 0); 
                      });
                    },
                  ),
                ),
                SizedBox(width: 8),
                DropdownButton<Kontinent>(
                  value: kontinenti.isNotEmpty ? kontinenti[0] : null,
                  onChanged: (value) {
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
                    String naziv = ''; 
                    int kontinentId = 0;
                    searchDrzave(naziv, kontinentId);
                  },
                  child: Text('Pretraga'),
                  
                ),
                SizedBox(width: 8,),
                  ElevatedButton(onPressed: ()async {
                         Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) =>  DodavanjeDrzaveScreen(),
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
             rows: drzave
                  .map(
                    (Drzava e) => DataRow(
                      onSelectChanged: (selected) {
                        if (selected == true) {
                          Navigator.of(context).push(
                            MaterialPageRoute(
                              builder: (context) => DodavanjeDrzaveScreen(drzava: e as Drzava),
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
class Kontinent {
  final int id;
  final String naziv;

  Kontinent({
    required this.id,
    required this.naziv,
  });
}

