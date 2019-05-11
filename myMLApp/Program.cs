using System;
using MyMLAppML.Model.DataModels;
using Microsoft.ML;

namespace myMLApp
{

    class Program
    {

        static void Main(string[] args)
        {
            ConsumeModel();
        }

        public static void ConsumeModel()
        {
            // Load the model
            MLContext mlContext = new MLContext();

            ITransformer mlModel = mlContext.Model.Load("MLModel.zip", out var modelInputSchema);

            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            // digitar frase
            Console.WriteLine("Digite frase para avaliação");

            // Use the code below to add input data
            var input = new ModelInput();
            input.SentimentText = Console.ReadLine();

            // Try model on sample data
            ModelOutput result = predEngine.Predict(input);

            if (!result.Prediction)
            {
                Console.WriteLine("Tá tranquilo campeão");
            }
            else
            {
                Console.WriteLine("TÓXICO MOTHERF...!!");
            }
        }
    }
}