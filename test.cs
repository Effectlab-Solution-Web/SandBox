private List<CiaAerea> ValidaCadastroCiaAerea()
        {
            List<CiaAerea> itens = new List<CiaAerea>();
            try
            {
                if (!String.IsNullOrEmpty(hddCiaAereaValida.Value))
                {
                    string[] itensArray = hddCiaAereaValida.Value.Split(',');
		    //teste	
                    foreach (var i in itensArray)
                    {
                        if (bll.ListaCiasAereasPorSigla(i.ToString()).Any())
                        {
                            CiaAerea item = new CiaAerea();
                            item.IATA = i.Trim().ToString();
                            item.CodCiaAerea = !string.IsNullOrEmpty(i) ? bll.ListaCiasAereasPorSigla(item.IATA).Where(s => s.IATA.Trim().ToUpper().Equals(i.Trim().ToUpper())).First().CodCiaAerea : 0;
                            itens.Add(item);
                        }
                        else
                        {
                            throw new Exception(string.Format("Não foi possível localizar a IATA {0} na caixa de seleção 'Lista de Cias. selecionadas'. Só é permitido IATAs cadastradas previamente no sistema." , i.ToString().ToUpper()));
                        }
                    }
                }
                return itens;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
