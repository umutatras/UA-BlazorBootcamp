using System.Resources;
using Xabe.FFmpeg;

var videoFilePath = "C:\\Users\\eftel\\Desktop\\Sam-Bankman-Fried.mp4";

string audioFilePath = Path.ChangeExtension(videoFilePath, "mp3");
//FFmpeg.SetExecutablesPath(); dosya yolunuda vererek proje içinde tutmadan işlem yapabiliriz.

CancellationTokenSource cts=new CancellationTokenSource();
var conversion = await FFmpeg.Conversions.FromSnippet.ExtractAudio(videoFilePath, audioFilePath);
await conversion.Start(cts.Token);


Console.WriteLine("Conversion Completed.");
Console.WriteLine(audioFilePath);