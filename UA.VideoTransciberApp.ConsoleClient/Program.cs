using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using System;
using System.Resources;
using Xabe.FFmpeg;
using OpenAI.Managers;
using OpenAI;

var videoFilePath = "C:\\Users\\eftel\\Desktop\\Sam-Bankman-Fried.mp4";

string audioFilePath = Path.ChangeExtension(videoFilePath, "mp3");
//FFmpeg.SetExecutablesPath(); dosya yolunuda vererek proje içinde tutmadan işlem yapabiliriz.

CancellationTokenSource cts=new CancellationTokenSource();
var conversion = await FFmpeg.Conversions.FromSnippet.ExtractAudio(videoFilePath, audioFilePath);
await conversion.Start(cts.Token);


Console.WriteLine("Conversion Completed.");
Console.WriteLine(audioFilePath);

const string fileName = "Sam-Bankman-Fried.mp3";
var sampleFile = await File.ReadAllBytesAsync(audioFilePath);
var openAiService = new OpenAIService(new OpenAiOptions()
{
    ApiKey = ""
});
var audioResult = await openAiService.Audio.CreateTranscription(new AudioCreateTranscriptionRequest
{
    FileName = fileName,
    File = sampleFile,
    Model = Models.WhisperV1,
    ResponseFormat = StaticValues.AudioStatics.ResponseFormat.Srt
});
if (audioResult.Successful)
{
    Console.WriteLine(string.Join("\n", audioResult.Text));
}
else
{
    if (audioResult.Error == null)
    {
        throw new Exception("Unknown Error");
    }
    Console.WriteLine($"{audioResult.Error.Code}: {audioResult.Error.Message}");
}