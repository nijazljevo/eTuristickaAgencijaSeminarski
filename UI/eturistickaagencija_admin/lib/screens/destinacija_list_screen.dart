import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import '../utils/util.dart';
import 'destinacija_details_screen.dart';

class DestinacijaListScreen extends StatefulWidget {
  const DestinacijaListScreen({super.key});

  @override
  // ignore: library_private_types_in_public_api
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
      // ignore: avoid_print
      print(error);
    }

    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Destinacije'),
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
                        searchDestinacije(value,0, 0,0); 
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
                    int gradId = 0; 
                    searchDestinacije(naziv,gradId,drzavaId, kontinentId);
                  },
                  child: const Text('Pretraga'),

                ),
                const SizedBox(width: 8,),
                  ElevatedButton(onPressed: ()async {
                    
                         Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) =>  const DestinacijaDetailsScreen(),
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
                         // ignore: unnecessary_null_comparison
                         DataCell(e.slika != null && e.slika != ""
  // ignore: sized_box_for_whitespace
  ? Container(
      width: 100,
      height: 100,
      child: imageFromBase64String(e.slika!),
    )
  : const Text(""))

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


