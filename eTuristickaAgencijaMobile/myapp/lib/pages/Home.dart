import 'package:flutter/material.dart';

import 'Login.dart';

class Home extends StatefulWidget {
  static const String routeName = "/home";

  const Home({Key? key}) : super(key: key);

  @override
  State<Home> createState() => _HomeState();
}

class _HomeState extends State<Home> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('eTuristickaAgencija'),
          backgroundColor: Colors.blue[900],
        ),
        drawer: Drawer(
          backgroundColor: Colors.blue[900],
          child: ListView(
            children: [
              const Padding(padding: EdgeInsets.all(10)),
              const SizedBox(
                height: 30,
              ),
             
              ListTile(
                title: const Text('Profil'),
                textColor: Colors.white,
                onTap: () {
                  Navigator.of(context).pushNamed('/profil');
                },
              ),
             
              ListTile(
                title: const Text('Odjavi se'),
                textColor: Colors.white,
                onTap: () {
                  Navigator.push(context,
                      MaterialPageRoute(builder: (context) => const Login()));
                },
              )
            ],
          ),
        ),
        body: SingleChildScrollView(
            child: Padding(
                padding: const EdgeInsets.all(20),
                child: Column(
                    mainAxisAlignment: MainAxisAlignment.start,
                    children: const [
                      SizedBox(
                        height: 35,
                      ),
                      Text(
                        'Dobrodošli na eTuristicka agencija...',
                        style: TextStyle(fontSize: 25, color: Colors.black),
                      ),
                    ]))));
  }
}