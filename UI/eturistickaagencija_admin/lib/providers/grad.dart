
import 'package:eturistickaagencija_admin/models/grad.dart';
import 'package:eturistickaagencija_admin/providers/base_provider.dart';


class GradProvider extends BaseProvider<Grad>{
  GradProvider():super("Gradovi");

  @override
  Grad fromJson(data) {
    // TODO: implement fromJson
    return Grad.fromJson(data);
  }

}