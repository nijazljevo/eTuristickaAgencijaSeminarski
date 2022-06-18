import 'package:flutter/cupertino.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

import '../../widgets/master_screen.dart';

class DrzaveDetailsScreen extends StatefulWidget {
  static const String routeName = "/drzave_details";
  String id;
  DrzaveDetailsScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<DrzaveDetailsScreen> createState() => _DrzaveDetailsScreenState();
}

class _DrzaveDetailsScreenState extends State<DrzaveDetailsScreen> {
  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Center(child: Text(this.widget.id),),
    );
  }
}