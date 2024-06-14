//using BlazorApp.Shared.Handlers;
//using BlazorApp.Shared.Models;
//using BlazorApp.Shared.Requests.ListasPresencas;
//using iTextSharp.text;
//using iTextSharp.text.pdf;

//namespace BlazorApp.Pages.ListasPresencas.Report
//{
//    public class RpTListaPresenca 
//    {
//        #region Configuracao do Documento
//        int _maxColumn = 3;
//        Document _document;
//        PdfPTable _pdfPTable = new PdfPTable(3);
//        PdfPCell _pdfPCell;
//        Font _fontStyle;
//        MemoryStream _memoryStream = new MemoryStream();
//        List<ListaPresenca> _listaPresencas = new List<ListaPresenca>();
//        #endregion

//        public byte[] Report(List<ListaPresenca> listaPresencas)
//        {
//            _listaPresencas = listaPresencas;

//            _document = new Document(PageSize.A4, 10f, 10f, 20f, 30f);
//            _pdfPTable.WidthPercentage = 100;
//            _pdfPTable.HorizontalAlignment=Element.ALIGN_LEFT;
//            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
//            PdfWriter.GetInstance(_document, _memoryStream);
//            _document.Open();

//            float[] sizes = new float[_maxColumn];
//            for (int i = 0; i < _maxColumn; i++)
//            {
//                if (i == 0) sizes[i] = 50;
//                else sizes[i] = 100;
//            }

//            _pdfPTable.SetWidths(sizes);

//            this.ReportHeader();
//            this.ReportBody();

//            _pdfPTable.HeaderRows = 2;
//            _document.Add(_pdfPTable)
//            _document.Close();

//            return _memoryStream.ToArray();

//        }

//        private void ReportHeader()
//        {
//            _pdfPCell = new PdfPCell(this.SetPageTitle());
//            _pdfPCell.Colspan = _maxColumn - 1;
//            _pdfPCell.Border = 0;
//            _pdfPTable.AddCell(_pdfPCell);

//            _pdfPTable.CompleteRow();
//        }

//        private PdfPTable SetPageTitle()
//        {
//            int maxColumn = 3;
//            PdfPTable pdfPTable = new PdfPTable(maxColumn);

//            _fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);

//            _pdfPCell = new PdfPCell(new Phrase("Lista de Presença", _fontStyle));
//            _pdfPCell.Colspan = maxColumn;
//            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
//            _pdfPCell.Border = 0;
//            _pdfPCell.ExtraParagraphSpace = 0;
//            pdfPTable.AddCell(_pdfPCell);

//            pdfPTable.CompleteRow();

//            _pdfPCell = new PdfPCell(new Phrase("Nome do Curso", _fontStyle));
//            _pdfPCell.Colspan = maxColumn;
//            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
//            _pdfPCell.Border = 0;
//            _pdfPCell.ExtraParagraphSpace = 0;
//            pdfPTable.AddCell(_pdfPCell);

//            pdfPTable.CompleteRow();

//            return pdfPTable;
//        }
        
//        private void ReportBody()
//        {
//            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
//            var fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);

//            #region Table Header
//            _pdfPCell = new PdfPCell(new Phrase("Nome do Aluno", _fontStyle));
//            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
//            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
//            _pdfPCell.BackgroundColor = BaseColor.GRAY;
//            _pdfPTable.AddCell(_pdfPCell);

//            _pdfPCell = new PdfPCell(new Phrase("Assinatura", _fontStyle));
//            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
//            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
//            _pdfPCell.BackgroundColor = BaseColor.GRAY;
//            _pdfPTable.AddCell(_pdfPCell);

//            _pdfPCell = new PdfPCell(new Phrase("Data", _fontStyle));
//            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
//            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
//            _pdfPCell.BackgroundColor = BaseColor.GRAY;
//            _pdfPTable.AddCell(_pdfPCell);


//            _pdfPTable.CompleteRow();
//            #endregion

//            #region Table Body
//            foreach (var treinamento in Treinamento)
//            {
//                _pdfPCell = new PdfPCell(new Phrase("treinamento.Aluno.Nome", _fontStyle));
//                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
//                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
//                _pdfPCell.BackgroundColor = BaseColor.WHITE;
//                _pdfPTable.AddCell(_pdfPCell);

//                _pdfPCell = new PdfPCell(new Phrase("treinamento.Aluno.Assinatura", _fontStyle));
//                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
//                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
//                _pdfPCell.BackgroundColor = BaseColor.WHITE;
//                _pdfPTable.AddCell(_pdfPCell);

//                _pdfPCell = new PdfPCell(new Phrase("Data", _fontStyle));
//                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
//                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
//                _pdfPCell.BackgroundColor = BaseColor.WHITE;
//                _pdfPTable.AddCell(_pdfPCell);


//                _pdfPTable.CompleteRow();
//            }
//            #endregion       
//        }

//        // gerar lista esta no modelo no video que vi será que deve ser criado um request?

//        public void GeneratePDF(IJSRuntime iJSRuntime)
//        {
//            List<ListaPresenca> listas = new List<ListaPresenca>();
//            for (int i = 1; 1 <= 9; i++)
//            {
//                listas.Add(new ListaPresenca())
//                {
//                    nomeAluno = "nomeAluno",
//                    assinatura = "Assinatura",
//                    data = "data" 
//                });
//            }

//            RpTListaPresenca rptListaPresenca = new RpTListaPresenca();
//            iJSRuntime.InvokeAsync<ListaPresenca>(
//                "saveAsFile",
//                "ListaPresenca.pdf",
//                Convert.ToBase64String(rptListaPresenca.Report(listas))
//            );
//         }   
    
//    }

//}