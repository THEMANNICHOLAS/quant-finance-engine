Multi-Legged Options Watchlist & Strategy Engine

A high-performance Fintech application built with .NET 8 and React, designed to track complex options strategies (Spreads, Iron Condors) with real-time data persistence and low-latency updates.

🚀 Architectural Vision

This project is engineered with a "High-Performance First" mindset. It demonstrates the ability to manage strict external API limits through intelligent caching layers and background processing.

Key Technical Pillars

Hybrid Data Strategy: Uses PostgreSQL for persistent relational state (User watchlists, Strategy definitions) and Redis for ephemeral, high-frequency market data (Greeks, Bid/Ask).

The "Zero-Cost" OCC Generator: A custom C# implementation that formats OCC option symbols locally, saving 100% of API credits typically wasted on string formatting endpoints.

Event-Driven Updates: Utilizes SignalR (WebSockets) to push live price updates from a C# Background Worker directly to the client UI.

Strategy Templating: Implements a template-driven approach to complex multi-leg strategies (up to 4 legs), ensuring mathematical integrity without bloated backend logic.

🛠 Tech Stack

Backend: ASP.NET Core 8 (Web API + SignalR + Hosted Services)

Frontend: React (TypeScript) + Tailwind CSS

Database: PostgreSQL (Strategy persistence)

Caching: Redis (Short-TTL market data)

External API: MarketData.app (Starter Tier)

Infrastructure: Docker Compose (Local PG/Redis orchestration)

📊 Feature Set

Multi-Leg Watchlists: Group up to 4 legs into named strategies (Verticals, Iron Condors, Straddles).

Real-Time Polling: Background worker batches saved symbols and polls market data every 10 seconds.

Dynamic Option Chains: Exploration of strikes and DTEs with 12-hour Redis caching to minimize API hits.

Price Alerts: Event-driven notification system for target debit/credit levels.

Paper Trading: Simulated execution ledger to track strategy performance over time.

🏗 Project Structure

/src/Backend: ASP.NET Core Web API project.

/src/Frontend: React application.

/docs: Architectural diagrams (Mermaid) and requirements.

docker-compose.yml: Local environment setup for Postgres and Redis.

📝 Developer Note

This project is part of a Software Engineering portfolio focused on Fintech Architecture. It prioritizes resource efficiency, system decoupling, and the practical application of design patterns over surface-level UI design.