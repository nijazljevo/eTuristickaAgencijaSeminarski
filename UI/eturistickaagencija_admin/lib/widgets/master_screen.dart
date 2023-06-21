import 'package:eturistickaagencija_admin/main.dart';
import 'package:eturistickaagencija_admin/screens/hotel_details_screen.dart';
import 'package:eturistickaagencija_admin/screens/hotel_list_screen.dart';
import 'package:flutter/material.dart';
import '../screens/agencija_list_screen.dart';
import '../screens/destinacija_list_screen.dart';
import '../screens/drzava_list_screen.dart';
import '../screens/grad_list_screen.dart';
import '../screens/karta_list_screen.dart';
import '../screens/kontinent_list_screen.dart';
import '../screens/korisnik_list_screen.dart';
import '../screens/rezervacija_list_screen.dart';
import '../screens/termin_list_screen.dart';

class MasterScreenWidget extends StatefulWidget {
  Widget? child;
  String? title;
  Widget? title_widget;
  
   MasterScreenWidget({this.child,this.title,this.title_widget,Key? key}):super(key: key);

  @override
  State<MasterScreenWidget> createState() => _MasterScreenWidgetState();
}

class _MasterScreenWidgetState extends State<MasterScreenWidget> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title:widget.title_widget ?? Text(widget.title ?? "")
      ),
      drawer: Drawer(
        child: ListView(
          children: [
             ListTile(
              title: const Text('Back'),
              onTap: (){
                 Navigator.of(context).push(
                  MaterialPageRoute(builder: (context)=>  LoginPage(),),
                );
              },
            ),
            ListTile(
              title: const Text('Hoteli'),
              onTap: (){
                Navigator.of(context).push(
                  MaterialPageRoute(builder: (context)=>  HotelListScreen(),),
                );
              },
            ),
            //  ListTile(
            //   title: const Text('Detalji'),
            //   onTap: (){
            //     Navigator.of(context).push(
            //       MaterialPageRoute(builder: (context)=>  HotelDetailsScreen(),),
            //     );
            //   },
            // ),
              ListTile(
              title: const Text('Gradovi'),
              onTap: (){
                Navigator.of(context).push(
                  MaterialPageRoute(builder: (context)=>  GradoviScreen(),),
                );
              },
            ),
             ListTile(
              title: const Text('Kontinenti'),
              onTap: (){
                Navigator.of(context).push(
                  MaterialPageRoute(builder: (context)=>  const KontinentListScreen(),),
                );
              },
            ),
             ListTile(
              title: const Text('Drzave'),
              onTap: (){
                Navigator.of(context).push(
                  MaterialPageRoute(builder: (context)=>   DrzavaListScreen(),),
                );
              },
            ),
             ListTile(
              title: const Text('Agencija'),
              onTap: (){
                Navigator.of(context).push(
                  MaterialPageRoute(builder: (context)=>  const AgencijaListScreen(),),
                );
              },
            ),
            ListTile(
              title: const Text('Destinacije'),
              onTap: (){
                Navigator.of(context).push(
                  MaterialPageRoute(builder: (context)=>   DestinacijaListScreen(),),
                );
              },
            ),
              ListTile(
              title: const Text('Korisnici'),
              onTap: (){
                Navigator.of(context).push(
                  MaterialPageRoute(builder: (context)=>   KorisnikScreen(),),
                );
              },
            ),
             ListTile(
              title: const Text('Rezervacije'),
              onTap: (){
                Navigator.of(context).push(
                  MaterialPageRoute(builder: (context)=>   RezervacijeScreen(),),
                );
              },
            ),
             ListTile(
              title: const Text('Termini'),
              onTap: (){
                Navigator.of(context).push(
                  MaterialPageRoute(builder: (context)=>    TerminiScreen(),),
                );
              },
            ),
             ListTile(
              title: const Text('Karte'),
              onTap: (){
                Navigator.of(context).push(
                  MaterialPageRoute(builder: (context)=>   KartaScreen(),),
                );
              },
            ),
            
          ],
        ),
      ),
      body:  widget.child!
    );
  }
}