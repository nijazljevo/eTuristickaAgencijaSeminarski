import 'package:eturistickaagencija_admin/screens/rezervacija_details_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../models/rezervacija.dart';
import '../models/search_result.dart';
import '../widgets/master_screen.dart';
import '../providers/rezervacija_provider.dart';

class RezervacijeScreen extends StatefulWidget {
  const RezervacijeScreen({Key? key}) : super(key: key);

  @override
  State<RezervacijeScreen> createState() => _RezervacijeScreenState();
}

class _RezervacijeScreenState extends State<RezervacijeScreen> {
  late RezervacijaProvider _rezervacijaProvider;
  SearchResult<Rezervacija>? result;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    _rezervacijaProvider = context.read<RezervacijaProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title_widget: const Text("Lista rezervacija"),
      child: Container(
        child: Column(
          children: [
            _buildSearch(),
            _buildDataListView(),
          ],
        ),
      ),
    );
  }

  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Row(
        children: [
          ElevatedButton(
            onPressed: () async {
              print("Pretraga");

              var data = await _rezervacijaProvider.get();

              setState(() {
                result = data;
              });
            },
            child: const Text("Pretraga"),
          ),
          const SizedBox(
            width: 8,
          ),
          ElevatedButton(
            onPressed: () async {
               Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) =>  ReservationScreen(
                     
                    ),
                  ),
                ); 
            },
            child: const Text("Dodaj"),
          )
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
              label: Text(
                'ID',
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
            DataColumn(
              label: Text(
                'Cijena',
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
             DataColumn(
              label: Text(
                'Datum rezervacije',
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ],
          rows: result?.result
                  .map(
                    (Rezervacija e) => DataRow(
                      onSelectChanged: (selected) => {
                        if (selected == true)
                                  {
                                    Navigator.of(context).push(
                                      MaterialPageRoute(
                                        builder: (context) =>
                                            ReservationScreen(
                                          rezervacija: e,
                                        ),
                                      ),
                                    )
                                  }
                              },
                      cells: [
                        DataCell(Text(e.id?.toString() ?? "")),
                        DataCell(Text(e.cijena.toString() ?? "")),
                                                    DataCell(Text(
                              // ignore: unnecessary_null_comparison
                              e.datumRezervacije != null
                                  ? e.datumRezervacije.toString()
                                  : '',
                            )),

                      ],
                    ),
                  )
                  .toList() ??
              [],
        ),
      ),
    );
  }
}

