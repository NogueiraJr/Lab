import sys
import Utils
import requests

#url = "http://54.233.216.237/VestBem"
urlBase = "http://localhost:5000"

param = {'Content-Type':'application/json'}

def InserirClientes():
    for x in range(30):
        data = {'nomeCliente': 'Novo Cliente ' + str(x+1)}
        print(data)
        response = requests.post(urlBase + "/api/clientes/", params = param, json = data)
        Utils.RegLog(__name__ + "." + sys._getframe().f_code.co_name, str(response.status_code))
    Utils.RegLog("", "")

def AlterarClientes():
    for x in range(30):
        if ((x % 2) == 1):
            url = urlBase + "/api/clientes/" + str(x+1)
            data = {'Clientes_id': x+1, 'nomeCliente': 'Cliente Alterado ' + str(x+1)}
            print(url)
            print(data)
            response = requests.put(url, params = param, json = data)
            Utils.RegLog(__name__ + "." + sys._getframe().f_code.co_name, str(response.status_code))
    Utils.RegLog("", "")

def ConsultarClientes():
    response = requests.get(urlBase + "/api/clientes/obtertodos", param)
    Utils.RegLog(__name__ + "." + sys._getframe().f_code.co_name, str(response.status_code))
    Utils.RegLog("", "")