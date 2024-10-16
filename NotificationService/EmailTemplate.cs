namespace NotificationService
{
    public class EmailTemplate
    {
        public static string GetEmailHtmlFormat(string imageTrackDescription,string lastPrice, string currentPrice)
        {
            string htmlTemplate = $@"
        <!DOCTYPE html>
        <html lang='es'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>Notificación de cambio de precio</title>
            <style type='text/css'>
                *, html, body, div, span, applet, object, iframe, h1, h2, h3, h4, h5, h6, p, blockquote, pre, a, abbr, acronym, address, big, cite, code, del, dfn, em, font, img, ins, kbd, q, s, samp, small, strike, strong, sub, tt, var, b, u, i, center, dl, dt, dd, ol, ul, li, fieldset, form, label, legend, table, caption, tbody, tfoot, thead, tr, th, td, tr, select, input {{
                    appearance: inherit;
                    -moz-appearance: inherit;
                    -webkit-appearance: inherit;
                    background: transparent;
                    border: none;
                    border-radius: 0;
                    box-sizing: border-box;
                    margin: 0;
                    outline: 0;
                    padding: 0;
                    text-decoration: none;
                    list-style: none;
                    font-family: var(--main_font);
                    color: inherit;
                }}
                :root {{
                    font-size: 15px;
                    --main_font: 'Poppins', sans-serif;
                }}
                body {{
                    font-family: var(--main_font);
                }}
                .container {{
                    width: 100%;
                    height: 100vh;
                    background-color: #f0f0f0;        
                }}
                .main {{
                    width: 50rem;
                    margin: 0 auto;
                }}
                table {{
                    background-color: #ffffff;
                    border-radius: 5px;
                    padding: 2rem;
                }}
                table tr {{
                    text-align: center;
                }}
                h1 {{
                    font-size: 2rem;
                    text-align: center;
                    margin-bottom: 1rem;
                }}
                p {{
                    font-size: 1.1rem;
                    margin-bottom: 1rem;
                }}
                img {{
                    height: 3.5rem;
                }}
                td a {{
                    padding: 0.7rem 1.2rem;
                    background-color: #3C0753;
                    color: #fff !important;
                    border: none;
                    border-radius: 5px;
                    cursor: pointer;
                    font-size: 1rem;
                    transition: background-color 0.3s ease;
                }}
                td a:hover {{
                    background-color: #720455;
                }}
                .info {{
                    padding: 2rem;
                }}
                .info p,
                .info a {{
                    color: gray;
                    margin-bottom: 1rem;
                    font-size: 1rem;
                }}
                .info p:last-child {{
                    margin-top: 1rem;
                }}
                .info a {{
                    text-decoration: underline;
                }}
                .unsubscribe {{
                    font-size: 0.7rem;
                    padding-top: 1.5rem;
                    color: gray;
                }}
                .unsubscribe a{{ 
                    padding: unset;
                    background-color: unset;
                    color: gray !important;
                    border: none;
                    border-radius: unset;
                    font-size: 0.7rem;
                    text-decoration: underline;
                }}
                .unsubscribe a:hover {{
                    background-color: unset !important;
                    color: #3C0753;     
                }}
                @media screen and (max-width: 1800px) {{
                    :root {{
                        font-size: 14px;
                    }}
                }}
                @media screen and (max-width: 1550px) {{
                    :root {{
                        font-size: 13px;
                    }}
                }}
                @media screen and (max-width: 1290px) {{
                    :root {{
                        font-size: 12px;
                    }}
                }}
                @media screen and (max-width: 1170px) {{
                    :root {{
                        font-size: 11px;
                    }}
                }}
                @media screen and (max-width: 1024px) {{
                    :root {{
                        font-size: 10px;
                    }}
                }}
                @media screen and (max-width: 990px) {{
                    :root {{
                        font-size: 11px;
                    }}
                }}
                @media screen and (max-width: 899px) {{
                    :root {{
                        font-size: 10px;
                    }}
                }}
                @media screen and (max-width: 768px) {{
                    :root {{
                        font-size: 9px;
                    }}
                }}
                @media screen and (max-width: 699px) {{
                    :root {{
                        font-size: 8px;
                    }}
                }}
                @media screen and (max-width: 576px) {{
                    :root {{
                        font-size: 14px;
                    }}
                    .main {{
                        width: 100%;
                        margin: 0 !important;
                    }}
                }}
                @media screen and (max-width: 500px) {{
                    :root {{ 
                        font-size: 13px;
                    }}
                }}
                @media screen and (max-width: 450px) {{
                    :root {{
                        font-size: 11px;
                    }}
                }}
                @media screen and (max-width: 375px) {{
                    :root {{
                        font-size: 9px;
                    }}
                }}
            </style>
            <link href='https://fonts.googleapis.com/css2?family=Poppins:wght@400;700&display=swap' rel='stylesheet'>
        </head>
        <body>
            <div class='container'>
                <div class='main'>
                    <table>
                        <tr>
                            <td><img src='https://trackmyprice.co/assets/images/logo_purple.png' alt='TrackMyPrice'></td>
                        </tr>
                        <tr>
                            <td><h1>¡Hemos detectado un cambio en el precio de tu producto '{imageTrackDescription}'!</h1></td>
                        </tr>
                        <tr>
                            <td><p>Ultimo precio escaneado: ${lastPrice}, Precio actual escaneado : ${currentPrice}</p></td>
                        </tr>
                    </table>
                    <div class='info'>
                        <p>Has recibido este email porque estás registrado en TrackMyPrice. Consulta nuestra <a href='https://trackmyprice.co/privacy' target='_blank'>política de privacidad</a> para más información.</p>
                        <p>&copy; <span id='year'></span> TrackMyPrice.</p>
                    </div>
                </div>
            </div>
            <script type='text/javascript'>
                document.getElementById('year').innerText = new Date().getFullYear();
            </script> 
        </body>
        </html>";

            return htmlTemplate;
        }
    }
}

