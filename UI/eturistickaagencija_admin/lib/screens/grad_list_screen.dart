import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;


import 'grad_details_screen.dart';

class GradoviScreen extends StatefulWidget {
  const GradoviScreen({super.key});

  @override
  // ignore: library_private_types_in_public_api
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
      // ignore: avoid_print
      print(error);
    }

    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Gradovi'),
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
                        searchGradovi(value, 0,0); 
                      });
                    },
                  ),
                ),
                const SizedBox(width: 8),
                
                ElevatedButton(
                  onPressed: () {
                    String naziv = ''; 
                    int kontinentId = 0;
                    int drzavaId = 0; 
                    searchGradovi(naziv,drzavaId, kontinentId);
                  },
                  child: const Text('Pretraga'),
                  
                ),
                const SizedBox(width: 8,),
                  ElevatedButton(onPressed: ()async {
                    
                         Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) =>  const DodavanjeGradaScreen(),
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

