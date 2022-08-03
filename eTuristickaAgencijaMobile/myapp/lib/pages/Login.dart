import 'package:myapp/services/APIservice.dart';
import 'package:flutter/material.dart';

class Login extends StatefulWidget {
  const Login({Key? key}) : super(key: key);

  @override
  _LoginState createState() => _LoginState();
}

var result = null;

Future<void> login() async {
  result = await APIService.login();
}

class _LoginState extends State<Login> {
  TextEditingController usernameController = new TextEditingController();
  TextEditingController passwordController = new TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(40),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.start,
            children: [
             
              const Text(
                'eTuristickaAgencija',
                style: TextStyle(fontSize: 30, color: Colors.black),
              ),
              const SizedBox(height: 70),
              TextField(
                  controller: usernameController,
                  decoration: InputDecoration(
                      border: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(7)),
                      hintText: 'Korisničko ime')),
              const SizedBox(
                height: 10,
              ),
              TextField(
                  controller: passwordController,
                  obscureText: true,
                  decoration: InputDecoration(
                      border: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(7)),
                      hintText: 'Lozinka')),
              const SizedBox(
                height: 20,
              ),
              Container(
                  padding: const EdgeInsets.all(10),
                  height: 60,
                  width: 250,
                  decoration: BoxDecoration(
                      color: Colors.blue[900],
                      borderRadius: BorderRadius.circular(8)),
                  child: TextButton(
                      onPressed: () async {
                        APIService.username = usernameController.text;
                        APIService.password = passwordController.text;
                        await login();
                        if (result != null) {
                          print(result);                      
                          Navigator.of(context).pushReplacementNamed('/home');
                        } else {
                          ScaffoldMessenger.of(context).showSnackBar(
                            SnackBar(
                              behavior: SnackBarBehavior.floating,
                              backgroundColor: Colors.transparent,
                              elevation: 0,
                              content: Container(
                                padding: const EdgeInsets.all(16),
                                height: 50,
                                decoration: const BoxDecoration(
                                  color: Colors.red,
                                  borderRadius:
                                      BorderRadius.all(Radius.circular(20)),
                                ),
                                child: const Text(
                                    "Pogrešan username ili password!"),
                              ),
                            ),
                          );
                        }
                      },
                      child: const Text('Login',
                          textAlign: TextAlign.center,
                          style:
                              TextStyle(color: Colors.white, fontSize: 20)))),
              const SizedBox(
                height: 10,
              ),
          
            ],
          ),
        ),
      ),
    );
  }
}