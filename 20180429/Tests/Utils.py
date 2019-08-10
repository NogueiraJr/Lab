def RegLog(metodo, info):
    separador = ""
    if (len(metodo) > 0 and len(info) > 0 ): separador = ": "
    print(metodo + separador + info)