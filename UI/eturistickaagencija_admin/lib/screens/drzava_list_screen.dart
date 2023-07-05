import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'drzava_details_screen.dart';

class DrzavaListScreen extends StatefulWidget {
  const DrzavaListScreen({super.key});

  @override
  // ignore: library_private_types_in_public_api
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
      // ignore: avoid_print
      print(error);
    }
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Drzave'),
      ),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              children: [
                Expanded(
                  child: TextField(
                    decoration: const InputDecoration(
                      labelText: 'Naziv',
                    ),
                    onChanged: (value) {
                      setState(() {
                        searchDrzave(value, 0); 
                      });
                    },
                  ),
                ),
                const SizedBox(width: 8),
               
                ElevatedButton(
                  onPressed: () {
                    String naziv = ''; 
                    int kontinentId = 0;
                    searchDrzave(naziv, kontinentId);
                  },
                  child: const Text('Pretraga'),
                  
                ),
                const SizedBox(width: 8,),
                  ElevatedButton(onPressed: ()async {
                         Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) =>  const DodavanjeDrzaveScreen(),
                          ),
                        );
                  }, child: const Text("Dodaj"))
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

