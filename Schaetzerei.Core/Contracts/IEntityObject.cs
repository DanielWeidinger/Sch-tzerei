﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Schaetzerei.Core.Contracts
{
    /// <summary>
    /// Jede Entität muss eine Id und ein Concurrency-Feld haben
    /// Die Annotation [Timestamp] muss in der Klasse extra notiert werden.
    /// </summary>
    public interface IEntityObject
    {
        /// <summary>
        /// Eindeutige Identitaet des Objektes.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Die Version dieses Datenbank-Objektes. Diese Version wird beim Erzeugen (AddAsync) 
        /// automatisch und mit jeder Änderung neu gesetzt. 
        /// </summary>
        byte[] RowVersion { get; set; }
    }
}
