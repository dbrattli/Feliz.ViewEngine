# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.1](https://github.com/dbrattli/Feliz.ViewEngine/compare/v1.0.0...v1.0.1) (2025-12-02)


### Performance Improvements

* optimize HTML rendering for 35-55% faster performance ([dae37f6](https://github.com/dbrattli/Feliz.ViewEngine/commit/dae37f653090aa8145aea673b5aeb779667e11dd))
* optimize HTML rendering for 35-55% faster performance ([eb460a7](https://github.com/dbrattli/Feliz.ViewEngine/commit/eb460a7e02810cad1c83b2a77cb8df8f50087dde))

## [1.0.0](https://github.com/dbrattli/Feliz.ViewEngine/compare/v0.27.0...v1.0.0) (unreleased)

### Features

* First stable release of Feliz.ViewEngine
* Minimal event handler support in ReactElement DOM (not rendered, but available for inspection)

### Bug Fixes

* Fix Bulma.input properties being ignored (fixes #16, #22)
* Relax FSharp.Core dependency constraint to allow modern versions (fixes #27)
* Add Html.table overload for children elements (fixes #19)

### Build

* Add release-please for automated releases
* Add conventional commit enforcement for PRs
* Add dependabot for GitHub Actions updates
