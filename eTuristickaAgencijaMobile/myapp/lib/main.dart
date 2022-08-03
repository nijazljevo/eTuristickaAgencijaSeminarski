import 'package:myapp/pages/Profil.dart';
import 'package:flutter/material.dart';
import 'package:myapp/pages/Login.dart';
import 'package:myapp/pages/Home.dart';
import 'package:flutter_stripe/flutter_stripe.dart';

void main() {
 
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: const Login(),
      routes: {
        '/home': (context) => const Home(),
        '/profil': (context) => const Profil()
      },
    );
  }
}