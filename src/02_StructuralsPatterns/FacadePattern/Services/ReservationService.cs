using FacadePattern.Models;
using FacadePattern.Repositories;
using System;

namespace FacadePattern.Services
{
    public struct TicketParameters
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime When { get; set; }
        public byte NumberOfPlaces { get; set; }
    }

    public interface ITicketService
    {
        Ticket Buy(TicketParameters parameters);
        void Cancel(Ticket ticket);
    }

    public class TicketService : ITicketService
    {
        RailwayConnectionRepository railwayConnectionRepository;
        TicketCalculator ticketCalculator;
        ReservationService reservationService;
        PaymentService paymentService;
        EmailService emailService;

        public TicketService(RailwayConnectionRepository railwayConnectionRepository, TicketCalculator ticketCalculator, ReservationService reservationService, PaymentService paymentService, EmailService emailService)
        {
            this.railwayConnectionRepository = railwayConnectionRepository;
            this.ticketCalculator = ticketCalculator;
            this.reservationService = reservationService;
            this.paymentService = paymentService;
            this.emailService = emailService;
        }

        public Ticket Buy(TicketParameters parameters)
        {
            RailwayConnection railwayConnection = railwayConnectionRepository.Find(parameters.From, parameters.To, parameters.When);
            decimal price = ticketCalculator.Calculate(railwayConnection, parameters.NumberOfPlaces);
            Reservation reservation = reservationService.MakeReservation(railwayConnection, parameters.NumberOfPlaces);
            Ticket ticket = new Ticket { RailwayConnection = reservation.RailwayConnection, NumberOfPlaces = reservation.NumberOfPlaces, Price = price };
            Payment payment = paymentService.CreateActivePayment(ticket);

            if (payment.IsPaid)
            {
                emailService.Send(ticket);
            }

            return ticket;  
        }

        public void Cancel(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }

    public class ReservationService
    {
        public Reservation MakeReservation(RailwayConnection railwayConnection, byte numberOfPlaces)
        {
            return new Reservation { RailwayConnection = railwayConnection, NumberOfPlaces = numberOfPlaces };
        }

        public void CancelReservation(RailwayConnection railwayConnection, byte numberOfPlaces)
        {

        }
    }

}
