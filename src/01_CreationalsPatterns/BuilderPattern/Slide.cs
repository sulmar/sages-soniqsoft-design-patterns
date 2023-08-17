using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    // Abstract Builder
    public interface IPresentationBuilder
    {
        void AddSlide(Slide slide);

    }

    // Concrete Builder
    public class PdfPresentationBuilder : IPresentationBuilder
    {
        private PdfDocument pdf = new PdfDocument();
        public void AddSlide(Slide slide)
        {
            pdf.AddPage(slide.Text);
        }

        public PdfDocument GetPdfDocument()
        {
            return pdf;
        }
    }

    public class MoviePresentationBuilder : IPresentationBuilder
    {
        private Movie movie = new Movie();
        public void AddSlide(Slide slide)
        {
            movie.AddFrame(slide.Text, 3);
        }

        public Movie GetMovie()
        {
            return movie;
        }
    }

    public class Slide
    {
        public string Text { get; }

        public Slide(string text)
        {
            Text = text;
        }
    }

    // Director (nadzorca)
    public class Presentation
    {
        private IPresentationBuilder builder;

        public Presentation(IPresentationBuilder builder)
        {
            this.builder = builder;
        }

        private List<Slide> slides = new List<Slide>();

        public void AddSlide(Slide slide)
        {
            slides.Add(slide);
        }

        public void Export()
        {
            builder.AddSlide(new Slide("Copyright"));

                foreach(Slide slide in slides)
                {
                    builder.AddSlide(slide);
                }                            
        }
    }

    public enum PresentationFormat
    {
        PDF,
        Image,
        PowerPoint,
        Movie
    }

    public class PdfDocument
    {
        public void AddPage(string text)
        {
            Console.WriteLine($"Add a page to PDF");
        }
    }

    public class Movie
    {
        public void AddFrame(string text, int duration)
        {
            Console.WriteLine($"Add a frame to the movie");
        }
    }
}
