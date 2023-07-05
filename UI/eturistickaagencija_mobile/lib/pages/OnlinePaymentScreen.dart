import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import '../model/rezervacija.dart';



class OnlinePaymentScreen extends StatefulWidget {
  final Rezervacije reservation;
  const OnlinePaymentScreen({Key? key,required this.reservation}) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _OnlinePaymentScreenState createState() => _OnlinePaymentScreenState();
}

class _OnlinePaymentScreenState extends State<OnlinePaymentScreen> {

  Map<String, dynamic>? paymentIntent;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Placanje'),
      ),
      body: Center(
        child: TextButton(
          child: const Text('Izvrsite uplatu'),
          onPressed: ()async{
            await makePayment();
          },
          ),
      ),
    );
  }

   Future<void> makePayment() async {
  try {
    double amount = widget.reservation.cijena; 
    String amountString = amount.toStringAsFixed(2);
    paymentIntent = await createPaymentIntent(amountString , 'bam'); 
    if (paymentIntent != null) {
      
      await Stripe.instance.initPaymentSheet(
        paymentSheetParameters: SetupPaymentSheetParameters(
          paymentIntentClientSecret: paymentIntent!['client_secret'],
          style: ThemeMode.dark,
          merchantDisplayName: 'Nijaz'
        )
      );

     
      displayPaymentSheet();
    } else {
      // ignore: avoid_print
      print('Payment intent is null');
    }
  } catch (e, s) {
    // ignore: avoid_print
    print('exception:$e$s');
  }
}



  displayPaymentSheet() async {

    try {
      await Stripe.instance.presentPaymentSheet(
          ).then((value){
        showDialog(
          context: context,
          builder: (_) => AlertDialog(
            content: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                Row(
                  children: const [
                    Icon(Icons.check_circle, color: Colors.green,),
                    Text("Payment Successfull"),
                  ],
                ),
              ],
            ), 
          ));

        paymentIntent = null;

      }).onError((error, stackTrace){
        // ignore: avoid_print
        print('Error is:--->$error $stackTrace');
      });


    } on StripeException catch (e) {
      // ignore: avoid_print
      print('Error is:---> $e');
      showDialog(
          context: context,
          builder: (_) => const AlertDialog(
            content: Text("Cancelled "),
          ));
    } catch (e) {
      // ignore: avoid_print
      print('$e');
    }
  }

  //  Future<Map<String, dynamic>>
createPaymentIntent(String amount, String currency) async {
  try {
    int calculatedAmount = calculateAmount(amount);
    Map<String, String> body = {
      'amount': calculatedAmount.toString(),
      'currency': currency,
      'payment_method_types[]': 'card'
    };

    var response = await http.post(
      Uri.parse('https://api.stripe.com/v1/payment_intents'),
      headers: {
        'Authorization': 'Bearer sk_test_51LSdMQF0OoH4ZYTibzQ1uvjfQ66v1sSAWorOpsCw8NOjx6jjpLljlcHdVHqPQ0SCwkcUToScoEbbd1wRi6ghKsim00kO8gaDoO',
        'Content-Type': 'application/x-www-form-urlencoded'
      },
      body: body,
    );

    // ignore: avoid_print
    print('Payment Intent Body->>> ${response.body.toString()}');
    return jsonDecode(response.body);
  } catch (err) {
    // ignore: avoid_print
    print('err charging user: ${err.toString()}');
  }
}



 int calculateAmount(String amount) {
  final calculatedAmount = (double.parse(amount) * 100).toInt();
  return calculatedAmount;
}


}